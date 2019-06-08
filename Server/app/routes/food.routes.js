module.exports = (app) => {
    const food = require('../controllers/food.controller.js');

    // Create a new Food
    app.post('/api/foods', food.create);

    // Retrieve all Foods
    app.get('/api/foods', food.findAll);

    // Retrieve a single Food with foodId
    app.get('/api/foods/:foodId', food.findOne);

    // Update a Food with foodId
    app.put('/api/foods/:foodId', food.update);

    // Delete a Food with foodId
    app.delete('/api/foods/:foodId', food.delete);
}