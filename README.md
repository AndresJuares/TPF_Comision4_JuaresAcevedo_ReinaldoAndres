# TPF_Comision4_JuaresAcevedo_ReinaldoAndres

Se presentaron varios problemas con respecto al github, ya que no me dejaba subir las modificaciones que tenia en el local. Se pudo solucionar clonando el repositorio remoto
y transcribiendo los ejercicios hechos (Consulta 2 y consulta 1 ) para que sean ya registrados en el remoto.

Se presento dificultades en la consulta 2 debido a que se creaba un bucle en el foreach que se creaba, ya que llamba al parametro.gethijos y no al planeta1.gethijos 
(ver en el metodo) y se pudo solucionar luego de 2 horas buscando el posible problema.


Otro problema importante y tambien incluye el github es que se trabajo de una notebook en donde daba los famosos "pantallazos azules" y se reinicio tantas veces que en un momento
se perdio toda la informacion e implementacion de la clase Estrategia. De modo que se perdia todo lo avanzado durante parte de la mañana y mediodia, y se paso a una escritorio.
Lo que llevo mas perdida de tiempo y avance en el trabajo. A continuacion se sigue con las consultas 1 y 3 para posteriormente realizar los movimientos.



Se intento crear el metodo calcular movimiento mediante if para saber si era una hoja o no, si estaba cerca de la raiz o si debia atacar los planetas adyacentes. No se obtuvieron resultados ya que es complejo visualizar lo que interpreta o hace el metodo creado y asi no saber en que se está fallando.
Se crearan los diagramas UML y se hará el informe correspondiente.

La idea está en mente ya que, si el nodo es nulo(osea si es neutro), se busca al planeta que posea la IA. Luego se preguntará si ese planeta es una hoja o no, en caso de que lo sea, se debe aplicar caso recursivo para poder llegar desde la raiz hasta el planeta IA, caso contrario se recorrerán y se tomarán los hijos para conquistarlos y cada uno que se agregue, preguntará si es la raiz. En caso de que sea verdadero se reagruparan las tropas para así conquistar la raiz que es el objetivo.





Se implementaron los metodos para calcular el movimiento, de modo que no se pudo completar cuando el planeta IA es una hoja o si esta entre medio para volver a la raiz. Por otra parte, se pudo implementar con éxito que recorra los planetas adyacentes para asi poder ser conquistados, pero al retorno solo regresa de un solo planeta y no todos sus adyacentes.
