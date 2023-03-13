using Project1;
using System.Numerics;

namespace Location
{
    [PrimaryKey(nameof(locationname))]
    public class location
    {
        public string locationname { get; set; } = string.Empty;
        public string state { get; set; } = string.Empty;
        public string city { get; set; } = string.Empty;
        public int Zip { get; set; }
    }
}
