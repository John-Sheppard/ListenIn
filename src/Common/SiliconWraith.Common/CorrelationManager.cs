using System;
using System.Collections.Generic;


namespace VibeTribe.Common
{
    public class CorrelationManager
    {
        private const string TRANSACTION_SLOT_NAME = "VIBETRIBE.COMMON.CORRELATIONMANAGER";
        private const string ACTIVITY_ID_SLOT_NAME = "VIBETRIBE.COMMON.ACTIVITYID";
        private const string ACTIVITY_NAME_SLOT_NAME = "VIBETRIBE.COMMON.ACTIVITYNAME";
        private readonly static AsyncLocal< Stack<KeyValuePair<Guid, string>> > asyncStorage = null;


        static CorrelationManager()
        {
            asyncStorage = new AsyncLocal<Stack<KeyValuePair<Guid, string>>>(ThreadContextChanged);
        }

        public static Guid CurrentActivityId
        {
            get
            {
                return asyncStorage.Value != null && asyncStorage.Value.Count > 0 ? asyncStorage.Value.Peek().Key : Guid.Empty;
            }
        }

        private static void ThreadContextChanged(AsyncLocalValueChangedArgs<Stack<KeyValuePair<Guid, string>>> changedArgs)
        {
            if (changedArgs.ThreadContextChanged && changedArgs.CurrentValue != null && changedArgs.CurrentValue != null)
            {
                asyncStorage.Value = null;

            }
        }

        public static Stack<KeyValuePair<Guid, string>> LogicalOperationStack
        {
            get
            {
                return GetLogicalOperationStack();
            }
        }

        public static void StartLogicalOperation(Guid operationId, string description)
        {
            Stack<KeyValuePair<Guid, string>> idStack = GetLogicalOperationStack();
            idStack.Push(new KeyValuePair<Guid, string>(operationId, string.IsNullOrWhiteSpace(description) ? "undefined" : description));
        }

        public static void StartLogicalOperation(Guid operationId)
        {
            StartLogicalOperation(operationId, string.Empty);
        }

        public static void StartLogicalOperation()
        {
            StartLogicalOperation(Guid.NewGuid());
        }

        public static void StopLogicalOperation()
        {
            Stack<KeyValuePair<Guid, string>> idStack = GetLogicalOperationStack();
            idStack.Pop();
        }

        private static Stack<KeyValuePair<Guid, string>> GetLogicalOperationStack()
        {
            Stack<KeyValuePair<Guid, string>> idStack = asyncStorage.Value != null && asyncStorage.Value.Count > 0 ? asyncStorage.Value : null;
            if (idStack == null)
            {
                asyncStorage.Value =  new Stack<KeyValuePair<Guid, string>>();
                
            }
            return idStack;
        }
    }
}
