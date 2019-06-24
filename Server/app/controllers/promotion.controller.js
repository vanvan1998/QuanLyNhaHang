const Promotion = require('../models/promotion.model.js');

// Create and Save a new Promotion
exports.create = async function (req, res) {
    try {

        // Create a Promotion
        const promotion = new Promotion({
            code: req.body.code,
            type: req.body.type,
            value: req.body.value,
            rule: req.body.rule,
            active: true
        });

        // Save Promotion in the database
        promotion.save()
            .then(data => {
                res.send({ message: "successful" });
            }).catch(err => {
                res.send({
                    message: err.message || "Some error occurred while creating the Promotion."
                });
            });
    } catch (error) {
        res.send({ message: error });
    }
};

// Retrieve and return Promotions
exports.find_all = async (req, res) => {
    try {
        var promotion = await Promotion.find();
        res.send(promotion);
    } catch (error) {
        res.send({ message: error });
    }
};

exports.update = async (req, res) => {
    try {
        var active = false;
        if (req.body.active == "True") {
            active = true;
        }
        await Promotion.findByIdAndUpdate(req.params.promotion_id, {
            code: req.body.code,
            type: req.body.type,
            value: req.body.value,
            active: active,
            rule: req.body.rule
        }, { new: true });
        res.send({ message: "successful" });
    } catch (error) {
        res.send({ message: error });
    }
};

exports.delete = async (req, res) => {
    try {
        await Promotion.findByIdAndRemove(req.params.promotion_id);
        res.send({ message: "successful" });
    } catch (error) {
        res.send({ message: error });
    }
};