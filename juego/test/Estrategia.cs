
using System;
using System.Collections.Generic;
namespace DeepSpace
{

	class Estrategia
	{
		
		
		public String Consulta1( ArbolGeneral<Planeta> arbol)
		{
			return "Implementar";
		}


		public String Consulta2( ArbolGeneral<Planeta> arbol)
		{
			return "Implementar";
		}


		public String Consulta3( ArbolGeneral<Planeta> arbol)
		{
			return "Implementar";
		}
		
		public Movimiento CalcularMovimiento(ArbolGeneral<Planeta> arbol)
		{
			// SI EL PLANETA ES VACIO, LLAMO A OBTENER PLANETA MAS CERCANO
			//PARA QUE ME RETORNE EL PLANETA QUE PERTENECE A LA IA
			ArbolGeneral<Planeta> Pl= null;
			if(Pl==null){
				Pl=ObtenerPlanetaCercano(arbol);
			}
			
			
			//CASO CONTRARIO
			
			return null;
		}
		
		//SI EL PLANETA DE LA IA ES UNA HOJA ENTONCES DEBO HACER EL RECORRIDO RECURSIVO
			public bool SaberSiEsHoja(ArbolGeneral<Planeta> Planeta1){
			if(Planeta1.getDatoRaiz().EsPlanetaDeLaIA()){
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
	}
}
