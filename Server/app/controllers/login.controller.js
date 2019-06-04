const User = require('../models/user.model.js');

// Create and Save a new User
exports.login = (req, res) => {
    // Validate username
    if (!req.body.username) {trf
        return res.status(400).send({
            message: "User user name can not be empty", 
            code : 0
        });
    }

    // Validate password
    if (!req.body.password) {
        return res.status(400).send({
            message: "User password can not be empty",
            code : 0
        });
    }

    // Find User in the database
    User.findOne({ "username": req.body.username})
        .then(user => {
            if (!user) {
                return res.send({
                    message: "User not found with username: " + req.body.username,
                    code: 0
                });
            }
            if (user.password == req.body.password) {
                res.send({
                    message: "Login successful",
                    role: user.role,
                    code: 1
                })
            }
            else {
                res.send({
                    message: "username or password is not correct ",
                    code: 0
                });
            }
        }).catch(err => {
            return res.send({
                message: "Error login user with username " + req.body.username,
                code: 0
            });
        });
};