
namespace register
{
    class Program
    {
        static void Main(string[] args)
        {
            controller.RunProgram run = new controller.RunProgram();
            run.runProgram();

        }
    }
}
    // TODO
    // Fel att lösa
    // menyn ska fortsätta rulla till anv väljer quit               ->
    // backa ett steg i menyn funkar ej                             ->
    // båtarna får alltid samma värden (sailboat, 0) ?              -> Check
    // felhantering av input från användaren                        -> Check
    // inkapsling av vissa data                                     ->
    // lösa hantering av id om medlemmar tas bort                   -> Check

    // requirements vad ska user kunna göra/anropa?
    // lägga till medlem -> metod i medlemsregister                 -> Check
    // hantera/ändra medlemsinformation -> metod i medlemsregister  -> Check
    // visa medlems information -> metod i medlemsregister          -> Check
    // ta bort medlem -> metod i medlemsregister                    -> Check 

    // visa lista på medlemmar compact list -> metod i listMembers  -> Check
    // visa lista på medlemmar verbose list -> metod i listMembers  -> Check

    // lägga till en båt för en medlem -> i båtregister             -> Check
    // ta bort en båt                                               -> Check
    // ändra på båtinfo                                             -> Check
