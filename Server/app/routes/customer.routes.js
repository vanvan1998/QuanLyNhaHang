module.exports = (app) => {
    const customer = require('../controllers/customer.controller.js');

    // Create a new customer
    app.post('/api/customers', customer.create);

    // Retrieve all customers
    app.get('/api/customers', customer.findAll);

    // Retrieve a single customer with customerId
    app.get('/api/customers/:customerId', customer.findOne);

    // Update a customer with customerId
    app.put('/api/customers/:customerId', customer.update);

    // Delete a customer with customerId
    app.delete('/api/customers/:customerId', customer.delete);
}