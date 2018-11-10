using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CPE200Lab1
{
    public partial class ExtendFromController : Form
    {
        private RPNCalculatorEngine engine;

        public ExtendFromController()
        {   
            engine = new RPNCalculatorEngine();
        }


        public string findResult(string input)
        {
            //get input form view and sent input to model
            return engine.Process(input);
        }
        
    }
}