const Customer = require('../models/customer.model.js');

// Create and Save a new Customer
exports.create = (req, res) => {
    // Validate customername
    if (!req.body.fullName) {
        return res.send({
            message: "Customer customer's name can not be empty"
        });
    }

    // Validate phone
    if (!req.body.phone) {
        return res.send({
            message: "Customer phone can not be empty"
        });
    }

    // Create a Customer
    const customer = new Customer({
        fullName: req.body.fullName,
        phone: req.body.phone
    });

    // Save Customer in the database
    customer.save()
        .then(data => {
            res.send(data);
            console.log("Send data!!");
        }).catch(err => {
            res.send({
                message: err.message || "Some error occurred while creating the Customer."
            });
        });
};

// Retrieve and return all customers from the database.
exports.findAll = (req, res) => {
    Customer.find()
        .then(customers => {
            res.send(customers);
        }).catch(err => {
            res.send({
                message: err.message || "Some error occurred while retrieving customers."
            });
        });
};

// Find a single customer with a customerId
exports.findOne = (req, res) => {
    Customer.findById(req.params.customerId)
        .then(customer => {
            if (!customer) {
                return res.send({
                    message: "Customer not found with id " + req.params.customerId
                });
            }
            res.send(customer);
        }).catch(err => {
            if (err.kind === 'ObjectId') {
                return res.send({
                    message: "Customer not found with id " + req.params.customerId
                });
            }
            return res.send({
                message: "Error retrieving customer with id " + req.params.customerId
            });
        });
};

// Update a customer identified by the customerId in the request
exports.update = (req, res) => {
    // Validate Request
    if (!req.body.fullName) {
        return res.send({
            message: "Customer password can not be empty"
        });
    }

    if (!req.body.phone) {
        return res.send({
            message: "Customer password can not be empty"
        });
    }

    // Find customer and update it with the request body
    Customer.findByIdAndUpdate(req.params.customerId, {
        fullName: req.body.fullName,
        phone: req.body.phone
    }, { new: true })
        .then(customer => {
            if (!customer) {
                return res.send({
                    message: "Customer not found with id " + req.params.customerId
                });
            }
            res.send(customer);
        }).catch(err => {
            if (err.kind === 'ObjectId') {
                return res.send({
                    message: "Customer not found with id " + req.params.customerId
                });
            }
            return res.send({
                message: "Error updating customer with id " + req.params.customerId
            });
        });
};

// Delete a customer with the specified customerId in the request
exports.delete = (req, res) => {
    Customer.findByIdAndRemove(req.params.customerId)
        .then(customer => {
            if (!customer) {
                return res.send({
                    message: "Customer not found with id " + req.params.customerId
                });
            }
            res.send({ message: "Customer deleted successfully!" });
        }).catch(err => {
            if (err.kind === 'ObjectId' || err.name === 'NotFound') {
                return res.send({
                    message: "Customer not found with id " + req.params.customerId
                });
            }
            return res.send({
                message: "Could not delete customer with id " + req.params.customerId
            });
        });
};