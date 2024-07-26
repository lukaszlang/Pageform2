using Soneta.Business;
using Soneta.SrodkiTrwale;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pageform2;
using Soneta.Handel;
using Soneta.CRM;
using Soneta.Types;

[assembly: Worker(typeof(khWorkers), typeof(Kontrahenci))]

namespace Pageform2
{


    public class khWorkers
    {
        [Context] public Session SS { get; set; }
        [Action("Pageform", Icon = ActionIcon.ArrowRight, Target = ActionTarget.Menu | ActionTarget.ToolbarWithText, Mode = ActionMode.SingleSession | ActionMode.NonAccept | ActionMode.SilentStartProgress, Priority = 1001)]
        public object WydanieNarzedzi()
        {
            var dok = new KlasaLLBase(SS);
            return dok;
        }

     

    }


    public class KlasaLLBase : ISessionable
    {

        public string opis { get; set; }
        public Soneta.Types.Date data { get;set; }
        public bool visibleSwitch;

        public string kodKreskowy
        {
            get { return ""; }
            set
            {
                visibleSwitch = !visibleSwitch;
                opis += "\n" + value;
            }
        }


        public KlasaLLBase(Session session)
        {

            Session = session;

        }

        public Session Session { get; set; }

        public bool IsVisibleInput1 { get { return visibleSwitch; } }
        public bool IsVisibleInput2 { get { return !visibleSwitch; } }
    }


  
}
