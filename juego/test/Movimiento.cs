using System;

namespace DeepSpace
{

	class Movimiento
	{
		//CONSTRUCTOR QUE TOMA COMO PARAMETRO EL PLANETA ORIGEN Y DESTINO DEL MOVIMIENTO.
		public Movimiento(Planeta o, Planeta d)
		{
			this.origen=o;
			this.destino=d;
		}
		
		
		public Planeta origen { get; set; }
		
		
		
		
		public Planeta destino { get; set; }
	}
}
