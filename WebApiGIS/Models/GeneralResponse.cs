namespace WebApiGIS.Models
{
    public class GeneralResponse
    {
        public bool IsPass { get; set; }

        public dynamic Data { get; set; }//obj | list |modelstate |Exeptiondescription |strint
    }
}
