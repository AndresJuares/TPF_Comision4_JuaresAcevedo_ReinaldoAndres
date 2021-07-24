
using System;
using System.Collections.Generic;
namespace DeepSpace
{

	class Estrategia
	{
		
		
		public String Consulta1( ArbolGeneral<Planeta> arbol)
		{
			
		
			//METODO PARA SABER CUAL ES EL CAMINO MAS LARGO DE LA RAIZ A UNA HOJA
			Cola<ArbolGeneral<Planeta>> cola=new Cola<ArbolGeneral<Planeta>>();
			cola.encolar(arbol);
			int cantnivel=0;
			int nivel=-1;
			while(!cola.esVacia()){
				//CREO EL CONTADOR PARA QUE ME TIRE EL CAMINO MAS LARGO
				cantnivel=cola.cantidad();
				while(cantnivel-->0){
					ArbolGeneral<Planeta> planeta1=cola.desencolar();
					foreach(ArbolGeneral<Planeta> hijo in planeta1.getHijos()){
						cola.encolar(hijo);	
					
					}
					
					
				}
				nivel++;
				
				
			}
			return"1) El camino mas largo hasta una hoja es: "+nivel;
			
			
				
		
		}


		public String Consulta2( ArbolGeneral<Planeta> arbol)
		{
			//METODO PARA RECORRER POR NIVELES E IMPRIMIR
			Cola<ArbolGeneral<Planeta>> cola=new Cola<ArbolGeneral<Planeta>>();
			cola.encolar(arbol);
			int contador =0;
			while(!cola.esVacia()){
				ArbolGeneral<Planeta> planeta1=cola.desencolar();
				//AL DESENCOLAR, PREGUNTO SI ESE PLANETA ES HOJA
				if(planeta1.esHoja()==true){
					//SI ES HOJA,PREGUNTO SI LA POBLACION ES MAYOR A 3
					if(planeta1.getDatoRaiz().Poblacion()>3){
						contador++;
					}
				}
			
				foreach(ArbolGeneral<Planeta> Hijo in planeta1.getHijos()){
					cola.encolar(Hijo);
				}
			}
			return "2) Los ultimos planetas que poseen poblacion mayor a 3 son: "+contador;
		}


		public String Consulta3( ArbolGeneral<Planeta> arbol)
		{
			
			//PRIMERO SE BUSCA EL PROMEDIO DE LA POBLACION
			
			long poblacionTotal=0;
			int TotalPlanetas=0;
			Cola<ArbolGeneral<Planeta>> cola=new Cola<ArbolGeneral<Planeta>>();
			cola.encolar(arbol);
			while(!cola.esVacia()){
				int planetasNivel=cola.cantidad();
				while(planetasNivel-->0){
					ArbolGeneral<Planeta> planeta=cola.desencolar();
					poblacionTotal+=(long)planeta.getDatoRaiz().Poblacion();
					TotalPlanetas++;
					foreach(ArbolGeneral<Planeta> Hijo in planeta.getHijos()){
						cola.encolar(Hijo);
					}
				}
			}
			
			//LUEGO SACO EL PROMEDIO DE CADA NIVEL
			double promedio=(double)poblacionTotal/TotalPlanetas;
			String Respuesta="3) Población mayor a la cantidad promedio del arbol:\n";
			int PlanetasmayorpromedioNivel,nivel=0;
			Cola<ArbolGeneral<Planeta>> cola2=new Cola<ArbolGeneral<Planeta>>();
			cola2.encolar(arbol);
			while(!cola2.esVacia()){
				int planetasNivel=cola2.cantidad();
				PlanetasmayorpromedioNivel=0;
				while(planetasNivel-->0){
					ArbolGeneral<Planeta> planeta2=cola2.desencolar();
					if(planeta2.getDatoRaiz().Poblacion()>promedio){
						PlanetasmayorpromedioNivel++;
					}
					foreach(ArbolGeneral<Planeta> Hijo2 in planeta2.getHijos()){
						cola2.encolar(Hijo2);
					}
				}
				Respuesta+=" NIVEL"+nivel +": "+ PlanetasmayorpromedioNivel;
				nivel++;
			}
			
			return Respuesta;
		}
		
		
		//CALCULO EL MOVIMIENTO PARA LA IA
		public Movimiento CalcularMovimiento(ArbolGeneral<Planeta> arbol)
		{
			// SI EL PLANETA ES VACIO, LLAMO A OBTENER PLANETA MAS CERCANO
			//PARA QUE ME RETORNE EL PLANETA QUE PERTENECE A LA IA
			ArbolGeneral<Planeta> planetaIA=null;
			
			
			//SI EL PLANETA ES VACIO, OBTENGO EL PLANETA QUE PERTENECE A LA IA
			if(planetaIA==null){
				planetaIA=ObtenerPlanetaCercano(arbol);
				if(planetaIA.esHoja()==true){
					
				}
			}
			//PREGUNTO SI TENGO QUE TRAER LAS TROPAS
			if(TengoQueReagrupar(planetaIA)){
				//EN CASO DE QUE SEA VERDADERO, RETORNO UN NUEVO MOVIMIENTO 
				Cola<ArbolGeneral<Planeta>> cola1=new Cola<ArbolGeneral<Planeta>>();
				while(!cola1.esVacia()){
					ArbolGeneral<Planeta>planeta1=cola1.desencolar();
					foreach(ArbolGeneral<Planeta> Hijo in planeta1.getHijos()){
						cola1.encolar(Hijo);
						new Movimiento(planetaIA.getDatoRaiz(),Hijo.getDatoRaiz());
					}
				}
				return new Movimiento(arbol.getDatoRaiz(),planetaIA.getDatoRaiz());
			}
			else{
				
				//EN CASO DE QUE SEA FALSO, CONQUISTO EL PLANETA
				//NEW MOVIMIENTO(ULTIMO PLANETA CONQUISTADO,PLANETANOCONQUISTADO)
				
				Cola<ArbolGeneral<Planeta>>cola2=new Cola<ArbolGeneral<Planeta>>();
				cola2.encolar(planetaIA);
				while(!cola2.esVacia()){
					ArbolGeneral<Planeta> planeta2=cola2.desencolar();
					foreach(ArbolGeneral<Planeta> Adyacentes in planeta2.getHijos()){
						cola2.encolar(Adyacentes);
						if(Adyacentes==planetaIA){
							Movimiento mov=new Movimiento(Adyacentes.getDatoRaiz(),planetaIA.getDatoRaiz());
							
							break;
						}
						if(Adyacentes.getDatoRaiz().EsPlanetaNeutral()==true){
							Movimiento movimiento=new Movimiento(planetaIA.getDatoRaiz(),Adyacentes.getDatoRaiz());
						}
						new Movimiento(planeta2.getDatoRaiz(),Adyacentes.getDatoRaiz());
						
					}
					
				}
			}
			
			
			//CASO CONTRARIO
			
			return null;
		}
		
		//SI EL PLANETA DE LA IA ES UNA HOJA ENTONCES DEBO HACER EL RECORRIDO RECURSIVO
		public bool SaberSiEsHoja(ArbolGeneral<Planeta> Planeta1){
			if(Planeta1.getHijos()==null){
				return true;
			}
			return false;
					
		}
		//CREO UN METODO PARA SABER QUE PLANETA ME TOCO EN EL ARBOL. INICIA SIEMPRE DESDE LA RAIZ QUE ES EL MEDIO
		private ArbolGeneral<Planeta> ObtenerPlanetaCercano(ArbolGeneral<Planeta> arbol){
			
			
			
			//CREO UNA COLA PARA HACER EL RECORRIDO
			Cola<ArbolGeneral<Planeta>> cola= new Cola<ArbolGeneral<Planeta>>();
			
			
			//ENCOLO EL ARBOL QUE SE ME PASO POR PARAMETRO
			cola.encolar(arbol);
			
			
			//MIENTRAS LA COLA NO ESTE VACIA
			while(!cola.esVacia()){
				//UTILIZO EL METODO POR NIVELES PARA BUSCAR EL PLANETA QUE PERTENECE A LA IA
				ArbolGeneral<Planeta> planeta= cola.desencolar();
				
				//PREGUNTO SI EL PLANETA DONDE ESTOY ES DE LA RAIZ
				if(planeta.getDatoRaiz().EsPlanetaDeLaIA()){
					//SI ES VERDADERO ME RETORNA TRUE.
					return planeta;
				}
			
			//PARA CADA PLANETA, LO AGREGO A LA COLA PARA QUE HAGA EL MISMO METODO HASTA ENCONTRAR EL PLANETA.
				foreach(ArbolGeneral<Planeta> PlanetaHijo in planeta.getHijos()){
					cola.encolar(PlanetaHijo);
				}
			}
			//EN CASO DE QUE NO SE ENCUENTRE EL PLANETA, RETORNARA FALSE.
			return null;
			
		}
		
		//METODO PARA REAGRUPAR LAS TROPAS
		private bool TengoQueReagrupar(ArbolGeneral<Planeta> arbol){
			if(!arbol.getDatoRaiz().EsPlanetaDeLaIA()){
				return false;
			}
			bool EstadoActual=true;
			foreach(ArbolGeneral<Planeta> Adyacentes in arbol.getHijos()){
				EstadoActual=EstadoActual & TengoQueReagrupar(Adyacentes);
			}
			return EstadoActual;
			
			
		}
	}
}
