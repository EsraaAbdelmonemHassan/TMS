namespace Domain
{
    public static class EmailTemplates
    {
        public const string Welcome = """
            <html><body>
            <h1>Welcome</h1>
            <p>Hello {{CustomerName}},</p>
            <p>Your account has been created.</p>
            </body></html>
            """;

        public const string OrderApproved = """
            <html><body>
            <h1>Order confirmed</h1>
            <p>Hello {{CustomerName}},</p>
            <p>Your order has been approved.</p>
            </body></html>
            """;
    }
}
