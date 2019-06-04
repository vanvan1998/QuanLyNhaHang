module.exports = (app) => {
    const loginController = require('../controllers/login.controller.js');

    // Check username and password
    app.post('/api/login', loginController.login);
}