using Microsoft.AspNetCore.Http;

namespace CourseWorkDuo.ViewModels
{
    // Note that this object is used as route options object. 
    // It means that it's properties will be serialized to query string.
    public class MessageVm
    {
        // All object properties are used as query param in redirect location.
        public string Msg { get; set; }


        private static MessageVm Empty = new MessageVm("");


        public bool HasValue()
        {
            bool hasValue = string.IsNullOrEmpty(Msg) == false;
            return hasValue;
        }

        // Used from controllers to redirect to a page and display message.
        public MessageVm(string message)
        {
            Msg = message;
        }

        // Used in view to create vm from request query.
        public static MessageVm ReadFromQueryString(IQueryCollection query)
        {
            string msg = query[nameof(Msg)];

            if (string.IsNullOrEmpty(msg)) return Empty;

            MessageVm vm = new MessageVm(msg);
            return vm;
        }
    }

}
