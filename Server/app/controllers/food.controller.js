const Food = require('../models/food.model.js');

// Create and Save a new Food
exports.create = (req, res) => {
    // Validate request
    if (!req.body.name) {
        return res.send({
            message: "Food's name can not be empty"
        });
    }

    // Validate request
    if (!req.body.price) {
        return res.send({
            message: "Food's price can not be empty"
        });
    }

    // Validate request
    if (!req.body.ingredients) {
        return res.send({
            message: "Food's ingredients can not be empty"
        });
    }

    // Validate request
    if (!req.body.type) {
        return res.send({
            message: "Food's type can not be empty"
        });
    }

    // Create a Food
    const food = new Food({
        name: req.body.name,
        price: req.body.price,
        ingredients: req.body.ingredients,
        type: req.body.status,
        note: req.body.note
        });

    // Save Food in the database
    food.save()
        .then(data => {
            res.send({ message: "create successful" });
        }).catch(err => {
            res.send({
                message: err.message || "Some error occurred while creating the Food."
            });
        });
};

exports.findAll = (req, res) => {

    Food.find()
        .then(foods => {
            res.send(foods);
        }).catch(err => {
            res.send({
                message: err.message || "Some error occurred while retrieving foods."
            });
        });
};

// Find a single food with a foodId
exports.findOne = (req, res) => {
    Food.findOne({ "name": req.params.name })
        .then(food => {
            if (!food) {
                return res.send({
                    message: "Food not found with id " + req.params.foodId,
                });
            }
            res.send({food, message : "successful"});
        }).catch(err => {
            if (err.kind === 'ObjectId') {
                return res.send({
                    message: "Food not found with id " + req.params.foodId,
                });
            }
            return res.send({
                message: "Error retrieving food with id " + req.params.foodId,
            });
        });
};

// Update a food identified by the foodId in the request
exports.update = (req, res) => {
    // Validate request
    if (!req.body.name) {
        return res.send({
            message: "Food's name can not be empty"
        });
    }

    // Validate request
    if (!req.body.price) {
        return res.send({
            message: "Food's price can not be empty"
        });
    }

    // Validate request
    if (!req.body.ingredients) {
        return res.send({
            message: "Food's ingredients can not be empty"
        });
    }

    // Validate request
    if (!req.body.type) {
        return res.send({
            message: "Food's type can not be empty"
        });
    }
    
    // Find food and update it with the request body
    Food.findByIdAndUpdate(req.params.foodId, {
        name: req.body.name,
        price: req.body.price,
        ingredients: req.body.ingredients,
        type: req.body.type,
        note: req.body.note
    }, { new: true })
        .then(food => {
            if (!food) {
                return res.send({
                    message: "Food not found with id " + req.params.foodId
                });
            }
            res.send({message: "Food updated successfully!"});
        }).catch(err => {
            if (err.kind === 'ObjectId') {
                return res.send({
                    message: "Food not found with id " + req.params.foodId
                });
            }
            return res.send({
                message: "Error updating food with id " + req.params.foodId
            });
        });
};

// Delete a food with the specified foodId in the request
exports.delete = (req, res) => {
    Food.findByIdAndRemove(req.params.foodId)
        .then(food => {
            if (!food) {
                return res.send({
                    message: "Food not found with id " + req.params.foodId
                });
            }
            res.send({ message: "Food deleted successfully!" });
        }).catch(err => {
            if (err.kind === 'ObjectId' || err.name === 'NotFound') {
                return res.send({
                    message: "Food not found with id " + req.params.foodId
                });
            }
            return res.send({
                message: "Could not delete food with id " + req.params.foodId
            });
        });
};