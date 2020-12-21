# OrionTek v2.0

Este repositorio contiene un solucion de Automatizacion basada en Selenium WebDriver + C#.

Para utilzar debe hacer lo siguiente:

1- Clonar el repositorio en Visual Studio (Community que es gratis)
2- Descargar la ultima version del ChromeDriver de Selenium y copiarlo en C:\Windows
3- Los resultados detallados de las pruebas estan en C:\TestResults

# Pruebas funcionales

Functional Tests:

1- Page response
2- Calculator Test
3- Max length test
4- Alphanumeric Character test
5- Links Tests

# Prueba funcional del Factorial Calculator:

1- Step: Open browser
   Expected: Browser opens

2- Step: Navigate to Factorial page url: http://qainterview.pythonanywhere.com
   Expected: Factorial Calculator page opens.

3- Step: Enter number in text box
   Expected: None

4- Step: Click on Calculate! button.
   Expected: Page will reload and show a text which shows the result of the factorial calculation in the following message: "The factorial of <number> is: <number>
 
# Bugs descubiertos

1- No hay mensaje de error cuando se excede de una cantidad de numeros maxima
2- Cualquier numero por encima de 990 no provee resultado
3- El titulo de la pagina esta mal escrito
4- La pagina de Terminos & Condiciones va a la pagina de Privacidad
5- La pagina de Privacidad va a la pagina de Terminos & Condiciones
6- El boton de Flecha no funciona
7- Caracteres como - y + son permitidos en frente de los numeros cuando se va a calcular.

 
