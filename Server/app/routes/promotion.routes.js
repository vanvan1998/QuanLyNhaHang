module.exports = (app) => {
    const promotion = require('../controllers/promotion.controller.js');

    // Create a new Promotion
    app.post('/api/promotions', promotion.create);

    // Retrieve all Promotions
    app.get('/api/promotions', promotion.findAll);
}