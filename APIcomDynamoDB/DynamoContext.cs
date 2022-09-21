using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DocumentModel;

namespace APIcomDynamoDB
{
    public class DynamoContext
    {
        private readonly AmazonDynamoDBClient client;
        private static string tableName = "ProductCatalog3";
        // The sample uses the following id PK value to add book item.
        //private static int sampleBookId = 555;
        private readonly Table table;

        public DynamoContext()
        {
            //Foi necessário usar o 'aws configure' para criar credenciais "fake", de modo a acessar o dynamoDb rodando no docker
            ///
            /// Acessar tabelas (no CMD):
            /// > aws dynamodb list-tables --endpoint-url http://localhost:8000
            /// Criar o .json de configuração da tabela:
            /// Executar o comando:
            /// > aws dynamodb create-table --cli-input-json file://db_create_config.json --endpoint-url http://localhost:8000
            AmazonDynamoDBConfig clientConfig = new();
            clientConfig.ServiceURL = "http://localhost:8000";

            client = new AmazonDynamoDBClient(clientConfig);

            table = Table.LoadTable(client, tableName);
        }

        public async void Add(Pessoa pessoa)
        {
            var item = pessoa.ToDocument();
            await table.PutItemAsync(item);
        }

        public async Task<Pessoa> Get(int id)
        {
            var doc = await Retrieve(id);
            return Pessoa.FromDocument(doc);
        }

        public async Task<Document> Retrieve(int id)
        {
            return await table.GetItemAsync(id);
        }
    }
}
