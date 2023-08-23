# Localizador_circulos

Ssistema computacional con la capacidad de seleccionar y analizar imágenes que
contienen círculos negros. Asumiendo que en las imágenes solamente hay círculos, y que todos son
negrosse debe considerar que las imágenes a analizar tienen ruido, los pixeles negros en los
bordes de las figuras no son completamente negros y por tanto, algunos círculos pueden ser
figuras ovales con radios similares. Todos los círculos están separados por, al menos, 5 pixeles
blancos. El sistema debe ser capaz de identificar círculos y borrar figuras ovales que superen los 10
pixeles de diferencia entre sus diámetros.

## Objetivo
Crear un programa con interfaz gráfica que permita analizar imágenes e identificar si en ésta hay
círculos negros u óvalos, y si existen óvalos eliminarlos. 

## Desarrollo
Para poder realizar el programa se ha utilizado el compilador de sharp develop.
Primero se ha agregado para interfaz gráfica dos botones, un picture box y un text box. Con la ayuda de
Open File Dialog es posible seleccionar archivos para poder agregar las imágenes a analizar.

Cuando se le da clic al botón analizar, se crea un bitmap a partir de la imagen seleccionada, lo que
permitirá la manipulación de los pixeles de la misma, se crea una lista de puntos con las coordenadas de los centroides y una lista
más de enteros que guardan la distancia del radio en pixeles.
Posteriormente se hace las iteraciones de todos los pixeles existentes en la imagen, esto para poder
encontrar un circulo negro. Se verifica de que color es el pixel y se pregunta si en esa coordenada
los colores especificados en el RGB son diferentes de 255 para rojo (R), 255 para verde (G) y 255 para
azul (B), es decir si el color es diferente de blanco, si lo es entonces se pregunta si las especificaciones
son diferentes de 100, 100 y 200, ya que esa combinación de colores son de un tono azul claro, que es
un color que próximamente se dibujará para ignorar el circulo ya analizado.

Find center es un método en el que se recibe una coordenada en _x_ y en _y_, y un bitmap, además que
devuelve un Point con coordenadas en _x_ y _y_ que señalan el punto medio del círculo.

radioCompare recibe como parámetro las coordenadas en x y y correspondientes al centro, y un bitmap. Desde el punto medio se
avanzan primero en _x_ y luego en _y_ hasta encontrar un pixel blanco. Cuando termina de encontrarlo en
los dos ejes, se saca la medida del radio para ambos ejes y se verifica si la diferencia entre el radio en x
y el radio en y no sobrepasa de seis pixeles, si lo hace se retorna un punto en x con valor a uno y la
medida del radio, si es un circulo se retorna otro punto con valor cero en _x_ y la medida del radio.
Antes de pintar cualquier tipo de circulo se verifica si del punto regresado en find radio en su valor _x_ es
igual a cero, si lo es se agregan a la lista el punto medio del circulo y el radio, además que manda
llamar el método is circle y posteriormente draw center. De no ser un circulo solo se manda llamar el
método de is circle.

Is circle es un método que recibe coordenadas en _x_ y _y_, un bitmap y un booleano. En este caso se manda
llamar a la función con las coordenadas del punto medio en x y a la altura del primer pixel encontrado
de color negro en _y_, esto para tener una mejor visibilidad en el método de paint circle.

En el método is circle si el booleano es verdadero se manda llamar el método paint circle mandando las
coordenadas recibidas en el método, un bitmap y un color. Cuando es un circulo se establece un color
azul establecido por ARGB, si es un ovalo se manda el color blanco para borrarlo.

Paint circle inicia desde el punto más alto del circulo en y y avanza pixel por pixel hasta que este sea
blanco, mientras tanto por cada que y avanza uno, se avanza en todos los pixeles pintándolos del color
correspondiente hasta que llegue a un pixel blanco tanto a la izquierda como a la derecha respecto a y.
Una ves pintados los pixeles se sobrescribe el picture box con el nuevo bitmap.

En el método de draw center se reciben las coordenadas del punto medio y dibuja un cuadrado de
10x10 al rededor del punto medio y mostrando el el picture box la nueva imagen creada.
Finalmente ya que se han hecho todas las operaciones se imprime toda la información respectiva de
cada circulo en el text box, haciendo iteraciones hasta que el indice sea de la misma cantidad al
contador que se ha usado para señalar cuantos círculos hubo en la imagen.
