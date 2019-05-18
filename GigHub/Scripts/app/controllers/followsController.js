var FollowsController = function(followService) {
	var followButton;

	var init = function(container) {
		$(container).on("click", ".js-toggle-follows", toggleFollow);
	};

	var toggleFollow = function(e) {
		followButton = $(e.target);

		var followId = followButton.attr("data-followed-id");

		if (followButton.hasClass("btn-default"))
			followService.followArtist(followId, done, fail);
		else 
			followService.unfollowArtist(followId, done, fail);
		

	};
	var done = function() {
		var text = (followButton.text() == "Following") ? "Follow" : "Following";
		followButton.toggleClass("btn-info").toggleClass("btn-default").text(text);
	};

	var fail = function() {
		alert("Cannot perform the action");
	};

	return {
		init: init
	}
}(FollowService);


