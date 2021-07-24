using System;
using System.Collections.Generic;
namespace DeepSpace
{

	class Movimiento
	{
		private List<Planeta> camino;
		private object Raiz;
		
		//CONSTRUCTOR QUE TOMA COMO PARAMETRO EL PLANETA ORIGEN Y DESTINO DEL MOVIMIENTO.
		public Movimiento(Planeta o, Planeta d)
		{
			this.origen=o;
			this.destino=d;
		}
		
		
		//CONSTRUCTOR CON LOS PARAMETROS DE TIPO LISTA
		public Movimiento(List<Planeta> camino,object raiz){
		
			this.camino=camino;
			this.Raiz=raiz;
		}
		
		
		public Planeta origen { get; set; }
		
		
		
		
		public Planeta destino { get; set; }
	}
}
