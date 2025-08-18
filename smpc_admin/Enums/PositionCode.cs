using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace smpc_admin.Enums
{
    public enum PositionCode
    {
        SalesInventory,
    }

    public static class PositionExtensions
    {
        //Add case here when adding new code
        public static string ToCodeString(this PositionCode position)
        {
            switch (position)
            {
                case PositionCode.SalesInventory:
                    return "SALES.INVENTORY";
                default:
                    return position.ToString();
            }
        }

        //Add case here when adding new code
      public static PositionCode? FromCodeString(string code)
          {

          switch (code)
              {
               case "SALES.INVENTORY":
                return PositionCode.SalesInventory;
               default:
                return null;
             }
     
         }

    }


}
