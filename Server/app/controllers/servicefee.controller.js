const Servicefee = require('../models/servicefee.model.js');

// Create and Save a new Servicefee
exports.create = async function (req, res) {
    try {
        // Create a Servicefee
        const servicefee = new Servicefee({
            type: req.body.type,
            fee: req.body.fee
        });

        // Save Servicefee in the database
        servicefee.save()
            .then(data => {
                res.send({ message: "successful" });
            }).catch(err => {
                res.send({
                    message: err.message || "Some error occurred while creating the Servicefee."
                });
            });
    } catch (error) {
        res.send({ message: error });
    }
};

// Retrieve and return Servicefees
exports.find_all = async (req, res) => {
    try {
        var servicefee = await Servicefee.find();
        res.send(servicefee);
    } catch (error) {
        res.send({ message: error });
    }
};

exports.findOne_with_type = async (req, res) => {
    try {
        var servicefee = await Servicefee.findOne({ type: req.params.type });
        res.send(servicefee);
    } catch (error) {
        res.send({ message: error });
    }
};

exports.update = async (req, res) => {
    try {
        await Servicefee.findByIdAndUpdate(req.params.servicefee_id, {
            type: req.body.type,
            fee: req.body.fee
        }, { new: true });
        res.send({ message: "successful" });
    } catch (error) {
        res.send({ message: error });
    }
};

exports.delete = async (req, res) => {
    try {
        await Servicefee.findByIdAndRemove(req.params.servicefee_id);
        res.send({ message: "successful" });
    } catch (error) {
        res.send({ message: error });
    }
};