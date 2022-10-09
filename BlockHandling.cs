using System.Windows.Forms;
using Tekla.Structures;
using Tekla.Structures.Model;

namespace Snekla
{
    public partial class Snekla : Form
    {
        private Identifier GenerateBlock(double x, double y, string type)
        {
            Beam block = new Beam();
            block.Name = type;
            block.Profile.ProfileString = "10*10";
            block.StartPoint = new Tekla.Structures.Geometry3d.Point(10 * x, 10 * y, -1);
            block.EndPoint = new Tekla.Structures.Geometry3d.Point(10 * x, 10 * y, 1);
            block.Material.MaterialString = "Concrete_Undefined";
            block.Position.Plane = Position.PlaneEnum.MIDDLE;
            block.Position.Depth = Position.DepthEnum.MIDDLE;
            block.Position.Rotation = Position.RotationEnum.TOP;

            if (type == "Border")
            {
                block.Class = "0";
            }
            else if (type == "Snake")
            {
                block.Class = "3";
            }
            else if (type == "Prize")
            {
                block.Class = "1";
            }
            block.Insert();
            return block.Identifier;


        }

        private void RemoveBlock(Identifier ID)
        {
            ModelObject modelObject = model.SelectModelObject(ID);
            modelObject.Delete();
            model.CommitChanges();
        }
    }

}