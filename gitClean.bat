git checkout --orphan temp_branch
git add -A
git commit -am "MatomoDeviceDetector.NET - Initial commit 11-05-2020"
git branch -D master
git branch -m master
git push -f origin master
