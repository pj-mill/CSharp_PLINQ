namespace CSharpPLINQ.DataAccess
{
    public class DataAccessManager
    {
        private CustomerDAO customerManager;
        private OrderDAO orderManager;
        private ProductDAO productManager;
        private OrderDetailDAO orderDetailManager;

        public CustomerDAO CustomerManager {
            get
            {
                if(customerManager == null)
                {
                    customerManager = new CustomerDAO();
                }
                return customerManager;
            }
        }

        public OrderDAO OrderManager
        {
            get
            {
                if(orderManager == null)
                {
                    orderManager = new OrderDAO();
                }
                return orderManager;
            }
        }

        public ProductDAO ProductManager
        {
            get
            {
                if(productManager == null)
                {
                    productManager = new ProductDAO();
                }
                return productManager;
            }
        }

        public OrderDetailDAO OrderDetailManager
        {
            get
            {
                if(orderDetailManager == null)
                {
                    orderDetailManager = new OrderDetailDAO();
                }
                return orderDetailManager;
            }
        }
    }
}
