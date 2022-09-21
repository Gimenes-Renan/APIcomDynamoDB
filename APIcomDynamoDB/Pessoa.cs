using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2.DocumentModel;

namespace APIcomDynamoDB
{
    public class Pessoa
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public int Idade { get; set; }


        public Pessoa(int id, string nome, int idade)
        {
            Id = id;
            Nome = nome;
            Idade = idade;
        }

        public Pessoa()
        {
        }

        public Document ToDocument()
        {
            var item = new Document
            {
                ["Id"] = Id,
                ["Nome"] = Nome,
                ["Idade"] = Idade,
            };
            return item;
        }

        public static Pessoa FromDocument(Document document)
        {
            return new Pessoa()
            {
                Id = document["Id"].AsInt(),
                Nome = document["Nome"].AsString(),
                Idade = document["Idade"].AsInt()
            };
        }
    }
}