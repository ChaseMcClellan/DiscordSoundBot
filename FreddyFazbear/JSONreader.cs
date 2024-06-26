using Newtonsoft.Json;
using System.IO;
using System.Threading.Tasks;

namespace FreddyFazbear
{
    public class JSONreader
    {
        public string token { get; set; }
        public string prefix { get; set; }
        public async Task ReadJSON()
        {
            using (StreamReader r = new StreamReader("config.json"))
            {
                string json = await r.ReadToEndAsync();
                JsonStruct data = JsonConvert.DeserializeObject<JsonStruct>(json);
                this.token = data.token;
                this.prefix = data.prefix;
            }
        }
    }

    internal sealed class JsonStruct
    {
        public string token { get; set; }
        public string prefix { get; set; }
    }
}