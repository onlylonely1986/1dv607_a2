
namespace register
{
    class Program
    {
        static void Main(string[] args)
        {
            model.TextFileSave t = new model.TextFileSave();
            controller.Controller c = new controller.Controller();
            while(c.RunProgram(t));
        }
    }
}