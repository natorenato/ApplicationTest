function ajax(props) {
    return new Promise((resolve, reject) => {

        let ajax = $.ajax({ ...props })

        ajax.done(function (json) {
            resolve(json)
        })

        ajax.fail(function (xhr) {
            reject(xhr)
        })
    })
}