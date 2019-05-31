module.exports = (app) => {
    const table = require('../controllers/table.controller.js');

    // Create a new Table
    app.post('/tables', table.create);

    // Retrieve all Tables
    app.get('/tables', table.findAll);

    // Retrieve a single Table with tableId
    app.get('/tables/:tableId', table.findOne);

    // Update a Table with tableId
    app.put('/tables/:tableId', table.update);

    // Delete a Table with tableId
    app.delete('/tables/:tableId', table.delete);
}