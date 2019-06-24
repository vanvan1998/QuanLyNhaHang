module.exports = (app) => {
    const servicefee = require('../controllers/servicefee.controller.js');

    // Create a new Servicefee
    app.post('/api/servicefees', servicefee.create);

    // Retrieve all servicefees
    app.get('/api/servicefees', servicefee.find_all);

    // Update a servicefee
    app.put('/api/servicefees/update/:promotion_id', servicefee.update);

    // Retrieve all servicefees
    app.delete('/api/servicefees/delete/:promotion_id', servicefee.delete);

    // Retrieve all servicefees
    app.get('/api/servicefees/:type', servicefee.findOne_with_type);

}