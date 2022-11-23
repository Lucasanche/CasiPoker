/* Habitacion congelada
   Invadida por el aburrimiento
   Hay 3 npc (solo habla 1)
*/


-> habitacion2

=== habitacion2 ===
Bienvenido a nuestra morada. Realmente no hay nada entretenido para hacer acá, no entendemos que podría resultarte tan atractivo como para permanecer más tiempo. Mira a tu alrededor ¿Qué hay? nada, nada y nada. Una fría y aburrida habitación... 
* [Así lo veo, por eso no me hagan perder el tiempo y ¡déjenme pasar!]
    #angry
    Esto es una falta de respeto, deberías ubicarte estando en casa ajena.
    * * [Tienen razón, me disculpo.]
    #bored
    Sus disculpas son aceptadas, volvamos a empezar. ->DONE
    * * [No es una falta de respeto, sigan con su aburrimiento y yo sigo mi camino.]
    No vamos a seguir soportando esta falta de respeto. -> DONE

// Enojo total, ataque. Lo que habíamos hablado de que lo atacaban y lo hacían cambiar de estado de materia.

* [Entiendo, es todo tan aburrido acá.]
    #bored
    Si y no tenemos nada para hacer. 
    * * [Bueno, son tres, podrían buscar algo para jugar.]
    ¿Algo como qué?
        * * * [Y... no sé, podrían hacer un torneo de piedra, papel o tijeras.]
        #happy2
        ¡Que buena idea!-> DONE
        * * * [Usen la imagiación ¿Tengo que pensar todo yo?]
        #angry
        Pero sos vos el que nos está proponiendo algo, hacete cargo!!! -> DONE

// se termina el diálogo, se debe reiniciar

    * * [Ustedes son una real perdida de tiempo sinceramente.]
    #angry
    ¡No tenés derecho a insultarnos en nuestra casa! -> DONE

// Puede seguir de enojo o reinicio de diálogo

    * * [¿Por qué la gallina cruzó la calle?]
    #bored
    ¿Qué? ¿Qué sentido tiene esa pregunta? ¿De qué nos sirve saber eso?
        * * * [Era un chiste para hacerlos reir...]
    #bored
    Ah... ¿Entonces? -> DONE
        * * * [Ah, además de aburridos no entienden un chiste tan fácil. Son un caso perdido.]
        #angry
        Lo mejor va a ser que te vayas -> DONE

// Enojo 
-> END
