module.exports = (app) => {
    const bill = require('../controllers/bill.controller.js');

    // Create a new Bill
    app.post('/api/bills', bill.create);

    // Retrieve all Bills
    app.get('/api/bills/', bill.findAll);

    // Retrieve a single Bill with billId
    app.get('/api/bill/:tableNumber', bill.findOne);

    // addFoodInBill a Bill with billId
    app.put('/api/addFoodInBill/:tableNumber', bill.addFoodInBill);

    // Delete a Bill with billId
    app.delete('/api/bills/:billId', bill.delete);
}