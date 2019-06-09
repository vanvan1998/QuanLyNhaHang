module.exports = (app) => {
    const table = require('../controllers/table.controller.js');

    // Create a new Table
    app.post('/api/tables', table.create);

    // Retrieve all Tables
    app.get('/api/tables/:status/:type', table.findAllWithStatusAndType);

    // Retrieve all Tables
    app.get('/api/tables', table.findAll);

    // Retrieve a single Table with tableNumber
    app.get('/api/tables/:tableNumber', table.findOne);

    // Update a Table with tableId
    app.put('/api/tables/:tableId', table.update);

    app.put('/api/tables/book/:tableNumber', table.book);

    // Delete a Table with tableId
    app.delete('/api/tables/:tableId', table.delete);
}