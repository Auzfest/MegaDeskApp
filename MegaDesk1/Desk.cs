using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace MegaDesk1
{
    public enum DesktopMaterial
    {
        Oak,
        Laminate,
        Pine,
        Rosewood,
        Veneer
    }

    public class Desk
    {
        public double Width { get; set; }
        public double Depth { get; set; }
        public int Drawers { get; set; }
        public DesktopMaterial Material { get; set; }


        public const double MIN_WIDTH = 24.0;
        public const double MAX_WIDTH = 96.0;
        public const double MIN_DEPTH = 12.0;
        public const double MAX_DEPTH = 48.0;

        public Desk(double width, double depth, int drawers, string material)
        {
            Width = width;
            Depth = depth;
            Drawers = drawers;
            List<DesktopMaterial> materials = Enum.GetValues(typeof(DesktopMaterial))
                                      .Cast<DesktopMaterial>()
                                      .ToList();
        }

        public double GetWidth()
        {
            return Width;
        }

        public double GetDepth()
        {
            return Depth;
        }

        public int GetDrawers()
        {
            return Drawers;
        }

        public string GetMaterial()
        {
            return Material.ToString();
        }
    }
}

