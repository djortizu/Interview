# OrionTek v2.0

Este repositorio contiene un solucion de Automatizacion basada en Selenium WebDriver + C#.

Para utilzar debe hacer lo siguiente:

1- Clonar el repositorio en Visual Studio (Community que es gratis)<br>
2- Descargar la ultima version del ChromeDriver de Selenium y copiarlo en C:\Windows<br>
3- Los resultados detallados de las pruebas estan en C:\TestResults<br>

# Pruebas funcionales

Functional Tests:

1- Page response<br>
2- Calculator Test<br>
3- Max length test<br>
4- Alphanumeric Character test<br>
5- Links Tests<br>

# Prueba funcional del Factorial Calculator:

1- Step: Open browser<br>
   Expected: Browser opens<br>

2- Step: Navigate to Factorial page url: http://qainterview.pythonanywhere.com<br>
   Expected: Factorial Calculator page opens.<br>

3- Step: Enter number in text box<br>
   Expected: None<br>

4- Step: Click on Calculate! button.<br>
   Expected: Page will reload and show a text which shows the result of the factorial calculation in the following message: "The factorial of <number> is: <number> <br>
 
# Bugs descubiertos

1- No hay mensaje de error cuando se excede de una cantidad de numeros maxima<br>
2- Cualquier numero por encima de 990 no provee resultado<br>
3- El titulo de la pagina esta mal escrito<br>
4- La pagina de Terminos & Condiciones va a la pagina de Privacidad<br>
5- La pagina de Privacidad va a la pagina de Terminos & Condiciones<br>
6- El boton de Flecha no funciona<br>
7- Caracteres como - y + son permitidos en frente de los numeros cuando se va a calcular.<br>

 
