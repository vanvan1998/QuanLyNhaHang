module.exports = (app) => {
    const user = require('../controllers/user.controller.js');

    // Create a new User
    app.post('/api/employees', user.create);

    // Retrieve all Users
    app.get('/api/employees', user.findAll);

    // Retrieve a single User with userId
    app.get('/api/employees/:userId', user.findOne);

    // Update a User with userId
    app.put('/api/employees/:userId', user.update);

    // Delete a User with userId
    app.delete('/api/employees/:userId', user.delete);
}