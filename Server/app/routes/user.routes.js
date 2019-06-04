module.exports = (app) => {
    const user = require('../controllers/user.controller.js');

    // Create a new User
    app.post('/api/users', user.create);

    // Retrieve all Users
    app.get('/api/users', user.findAll);

    // Retrieve a single User with userId
    app.get('/api/users/:userId', user.findOne);

    // Update a User with userId
    app.put('/api/users/:userId', user.update);

    // Delete a User with userId
    app.delete('/api/users/:userId', user.delete);
}