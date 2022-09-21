namespace APIcomDynamoDB
{
    public class DynamoRepository : IDynamoRepository
    {
        private readonly DynamoContext dynamoContext;

        public DynamoRepository(DynamoContext dynamoContext)
        {
            this.dynamoContext = dynamoContext;
        }

        public Pessoa CreateOnDb(Pessoa pessoa)
        {
            dynamoContext.Add(pessoa);
            return pessoa;
        }

        public async Task<Pessoa> GetOnDb(int id)
        {
            var result = await dynamoContext.Get(id);
            return result;
        }
    }
}
