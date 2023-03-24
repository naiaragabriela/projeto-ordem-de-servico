
namespace ManipulacaoListas
{
    public class OrdemServico
    {
        public int ID { get; set; }
        public string Description { get; set; }
        public List<string> Pecas { get; set; }
        public double Value { get; set; }

        public OrdemServico(int id, string description, double value, List<string>peca)
        {
            ID = id;
            Description = description;
            Pecas = peca;
            Value = value;
        }

        public override string ToString()
        {
            string pe = "";
            foreach (var item in Pecas)
            {
                pe += item + ";";
            }
            return ID + ";" + Description + ";"+ pe + Value;
        }

        public string ToUser()
        {
            return @"ID:"+ID+ "\n Descrição: " + Description + "\n Valor: " + Value;
        }
    }
}
