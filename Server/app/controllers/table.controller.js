const Table = require('../models/table.model.js');

// Create and Save a new Table
exports.create = (req, res) => {
    // Validate request
    if(!req.body.info) {
        return res.status(400).send({
            message: "Table info can not be empty"
        });
    }

    // Create a Table
    const table = new Table({
        number: req.body.number, 
        info: req.body.info
    });

    // Save Table in the database
    table.save()
    .then(data => {
        res.send(data);
        console.log("Send data!!");
    }).catch(err => {
        res.status(500).send({
            message: err.message || "Some error occurred while creating the Table."
        });
    });
};

// Retrieve and return all tables from the database.
exports.findAll = (req, res) => {
    Table.find()
    .then(tables => {
        res.send(tables);
    }).catch(err => {
        res.status(500).send({
            message: err.message || "Some error occurred while retrieving tables."
        });
    });
};

// Find a single table with a tableId
exports.findOne = (req, res) => {
    Table.findById(req.params.tableId)
    .then(table => {
        if(!table) {
            return res.status(404).send({
                message: "Table not found with id " + req.params.tableId
            });            
        }
        res.send(table);
    }).catch(err => {
        if(err.kind === 'ObjectId') {
            return res.status(404).send({
                message: "Table not found with id " + req.params.tableId
            });                
        }
        return res.status(500).send({
            message: "Error retrieving table with id " + req.params.tableId
        });
    });
};

// Update a table identified by the tableId in the request
exports.update = (req, res) => {
    // Validate Request
    if(!req.body.info) {
        return res.status(400).send({
            message: "Table info can not be empty"
        });
    }

    // Find table and update it with the request body
    Table.findByIdAndUpdate(req.params.tableId, {
        number: req.body.number,
        info: req.body.info
    }, {new: true})
    .then(table => {
        if(!table) {
            return res.status(404).send({
                message: "Table not found with id " + req.params.tableId
            });
        }
        res.send(table);
    }).catch(err => {
        if(err.kind === 'ObjectId') {
            return res.status(404).send({
                message: "Table not found with id " + req.params.tableId
            });                
        }
        return res.status(500).send({
            message: "Error updating table with id " + req.params.tableId
        });
    });
};

// Delete a table with the specified tableId in the request
exports.delete = (req, res) => {
    Table.findByIdAndRemove(req.params.tableId)
    .then(table => {
        if(!table) {
            return res.status(404).send({
                message: "Table not found with id " + req.params.tableId
            });
        }
        res.send({message: "Table deleted successfully!"});
    }).catch(err => {
        if(err.kind === 'ObjectId' || err.name === 'NotFound') {
            return res.status(404).send({
                message: "Table not found with id " + req.params.tableId
            });                
        }
        return res.status(500).send({
            message: "Could not delete table with id " + req.params.tableId
        });
    });
};