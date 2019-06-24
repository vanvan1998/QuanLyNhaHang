module.exports = (app) => {
    const promotion = require('../controllers/promotion.controller.js');

    // Create a new Promotion
    app.post('/api/promotions', promotion.create);

    // Retrieve all Promotions
    app.get('/api/promotions', promotion.find_all);

    // Create a new Promotion
    app.put('/api/promotions/update/:promotion_id', promotion.update);

    // Retrieve all Promotions
    app.delete('/api/promotions/delete/:promotion_id', promotion.delete);

}