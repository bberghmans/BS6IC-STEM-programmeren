using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weerstandsnetwerken
{
    public class WeerstandFactory
    {
        public enum WeerstandType
        {
            EnkelVoudig, SerieSchakeling, ParallelSchakeling
        }

        public static IWeerstand MaakWeerstand(WeerstandType weerstandstype)
        { 
        }
    }

    interface IWeerstand
    {

        public double EquivalenteWeerstand();
        public double BerekenSpanning(double stroom);
        public double BerekenStroom(double spanning);
    }
    internal class EnkelVoudigeWeerstand: IWeerstand
    {
        public double EffectieveWeerstand { get; set; }
        public string Name { get; set; }
    }

    internal class ParallelSchakeling : IWeerstand
    {
        public ParallelSchakeling(IWeerstand weerstand1, IWeerstand weerstand2)
        { }
    }

    internal class SerieSchakeling : IWeerstand
    {
        public SerieSchakeling(IWeerstand weerstand1, IWeerstand weerstand2)
        { }
    }
}
