
namespace register
{
    class Program
    {
        static void Main(string[] args)
        {
            controller.Controller c = new controller.Controller();
            while(c.RunProgram());
        }
    }
}