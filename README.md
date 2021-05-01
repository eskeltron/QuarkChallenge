Por favor, especifica tu nombre completo: Nicolás Gomez
1. **¿C# permite herencia múltiple?** 


    No, solo permite heredar 1 clase. Para simular la herencia multiple existen las interfaces.
2. ¿Cuándo utilizaría una Clase Abstracta en lugar de una Interfaz? 


    Utilizaría una clase abstracta cuando tengo que decir que una clase es "del tipo de", por ejemplo: La clase "Profesor" es del tipo "Persona". 
    
    Utilizaría una Interfaz cuando tengo que decir que una clase "se comporta como", por ejemplo: La clase "Pajaro" se comporta como un "Volador", entonces la interfaz sería "IVolador".
3. **¿Qué implica una relación de Generalización entre dos clases?** 


    Implica herencia, significa que la clase que apunta a otra clase con Generalización en el código tiene que heredar de esa clase.
4. **¿Qué implica una relación de Implementación entre una clase y una interfaz?** 


    Implica que la clase debe utilizar la interfaz, para que adquiera el comportamiento de esa interfaz.
5. **¿Qué diferencia hay entre la relación de Composición y la Agregación?** 


    Ambas son relaciones de asociación. La relación de asociación se divide en 2 tipos: Fuertes y débiles.
    Fuertes: Cuando una clase mantiene una referencia sobre otra. 
    Débiles: Cuando una clase tiene una relación con otra clase sin necesidad de mantenerlo.
    Tanto la relación de Composición como Agregación son Fuertes. Pero la diferencia es que:
    En la relación de Composición: 
        1) Cuando el todo es eliminado sus partes también
        2) La relación del todo con sus partes es que las partes se crean ni bien se crea el todo.
    En la relación de Agregación:
        1) Un todo puede mantener la relación con sus partes, y cuando el todo es eliminado no necesariamente sus partes también.
6. **Indique V o F según corresponda. Diferencia entre Asociación y Agregación:**


    Una diferencia es que la segunda indica la relación entre un “todo” y sus “partes”, mientras que en la primera los objetos están al mismo nivel contextual. **V**
    Una diferencia es que la Agregación es de cardinalidad 1 a muchos mientras que la Asociación es de 1 a 1. **F**
    Una diferencia es que, en la Agregación, la vida o existencia de los objetos relacionados está fuertemente ligada, es decir que si “muere” el objeto contenedor también     morirán las “partes”, en cambio en la Asociación los objetos viven y existen independientemente de la relación. **F**
