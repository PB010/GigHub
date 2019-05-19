var FollowService = function() {
	var createFollowing = function (followId, done, fail) {
		$.post("/api/follows", { followedId: followId})
			.done(done)
			.fail(fail);
	};

	var deleteFollowing = function(followId, done, fail) {
		$.ajax({
				url: "/api/follows/" + followId,
				method: "DELETE"
			})
			.done(done)
			.fail(fail);
	};

	return {
		createFollowing: createFollowing,
		deleteFollowing: deleteFollowing
}
}();