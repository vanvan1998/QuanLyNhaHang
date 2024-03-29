module.exports = (app) => {
    const bill = require('../controllers/bill.controller.js');

    // Create a new Bill
    app.post('/api/bills', bill.create);

    // Retrieve all Bills
    app.get('/api/bills', bill.findAll);

    // Retrieve a single Bill with billId
    app.get('/api/bills/:tableNumber', bill.findOne);

    app.get('/api/bills/bill/:billNumber', bill.findOneBill);

    app.get('/api/bills/foodInbill/:billNumber', bill.findFoodInBill);

    // addFoodInBill a Bill with billId
    app.put('/api/bills/addFoodInBill', bill.addFoodInBill);

    app.post('/api/bills/findCustomer', bill.findAllWithCustomerName);

    // increase amount of food
    app.put('/api/bills/increaseAmountFood', bill.increaseAmountFood);

    // decrease amount of food
    app.put('/api/bills/decreaseAmountFood', bill.decreaseAmountFood);
    
    // Delete a Bill with billId
    app.delete('/api/bills/:billId', bill.delete);

    // Get total of Bill
    app.get('/api/getTotalOfBill/:tableNumber', bill.getTotalBill);

    // Pay
    app.post('/api/bills/pay', bill.pay);

    // Get all bill from time to time
    app.post('/api/bills/filter', bill.filter);
}