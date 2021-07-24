using System;
namespace DeepSpace
{
    class IA: GameObject
    {
        private Estrategia est;
        private float acc;
        
        
        public IA(Game game)
            : base(game)
        {
            this.est = new Estrategia();
            
            
        }
        
        //METODO PARA RETORNAR LA ESTRATEGIA CREADA 
        public Estrategia GetEstrategia(){
        	return this.est;
        }

        public override void Update(float delta)
        {
            acc += delta;
            if (acc > 5)
            {
                GameScene gamescene = (GameScene)game.scene;
                Movimiento ataque = this.est.CalcularMovimiento(game.scene.arbolDePlanetas);
                if(ataque!=null)
                    gamescene.SendFleet(ataque.origen, ataque.destino);
                acc -= 5;
            }
        }

        
    }
}

