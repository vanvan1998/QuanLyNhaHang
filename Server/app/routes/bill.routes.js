module.exports = (app) => {
    const bill = require('../controllers/bill.controller.js');

    // Create a new Bill
    app.post('/api/bills', bill.create);

    // Retrieve all Bills
    app.get('/api/bills', bill.findAll);


    // Retrieve a single Bill with billId
    app.get('/api/bills/:billNumber', bill.findOne);

    // addFoodInBill a Bill with billId
    app.put('/api/bills/addFoodInBill', bill.addFoodInBill);


    app.put('/api/bills/increaseAmountFood', bill.increaseAmountFood);
    

    // Delete a Bill with billId
    app.delete('/api/bills/:billId', bill.delete);

    // Get total of Bill
    app.get('/api/getTotalOfBill/:tableNumber', bill.getTotalBill);

    // Pay
    app.post('/api/bills/pay', bill.pay);

    // Get all bill from time to time
    app.post('/api/bills/filter', bill.filter);
}