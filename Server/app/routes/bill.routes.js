module.exports = (app) => {
    const bill = require('../controllers/bill.controller.js');

    // Create a new Bill
    app.post('/api/bills', bill.create);

    // Retrieve all Bills
    app.get('/api/bills', bill.findAll);

    // Retrieve a single Bill with billId
    app.get('/api/bills/:tableNumber', bill.findOne);

    // addFoodInBill a Bill with billId
    app.put('/api/bills/addFoodInBill', bill.addFoodInBill);

    // Delete a Bill with billId
    app.delete('/api/bills/:billId', bill.delete);

    // Get total of Bill
    app.get('/api/getTotalOfBill/:tableNumber', bill.getTotalBill);
}