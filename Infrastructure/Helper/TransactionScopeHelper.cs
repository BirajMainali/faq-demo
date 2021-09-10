using System.Transactions;

namespace FAQ.Infrastructure.Helper
{
    public static class TransactionScopeHelper
    {
        public static TransactionScope Scope()
            => new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);
    }
}