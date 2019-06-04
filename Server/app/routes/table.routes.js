module.exports = (app) => {
    const table = require('../controllers/table.controller.js');

    // Create a new Table
    app.post('/api/tables', table.create);

    // Retrieve all Tables
    app.get('/api/tables', table.findAll);

    // Retrieve a single Table with tableId
    app.get('/api/tables/:tableId', table.findOne);

    // Update a Table with tableId
    app.put('/api/tables/:tableId', table.update);

    // Delete a Table with tableId
    app.delete('/api/tables/:tableId', table.delete);
}